<?php

namespace App\Controller;

use App\Entity\Posts;
use App\Form\PostFormType;
use Doctrine\ORM\EntityManagerInterface;
use Doctrine\Persistence\ManagerRegistry;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Annotation\Route;

class PostController extends AbstractController
{
    #[Route('/posts', name: 'app_posts')]
    public function index(ManagerRegistry $doctrine): Response
    {
        $repo = $doctrine->getRepository(Posts::class);
        $posts = $repo->findBy([], ['date_post' => 'DESC']);

        return $this->render('post/index.html.twig', [
            'posts' => $posts,
        ]);
    }

    #[Route('/posts/ajout', name: 'app_ajout_post')]
    public function ajoutPost(Request $request, EntityManagerInterface $entityManager): Response
    {
        $post = new Posts();
        $form = $this->createForm(PostFormType::class, $post);
        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {
            $post->setUtilisateur($this->getUser());
            $post->setDatePost(new \DateTime());
            $entityManager->persist($post);
            $entityManager->flush();

            return $this->redirectToRoute('app_posts');
        }

        return $this->render('post/ajout_post.html.twig', [
            'controller_name' => 'PageUtilisateurController',
            'postForm' => $form->createView(),
        ]);
    }

    #[Route('/posts/modifier/{id}', name: 'app_modifier_post')]
    public function modifierPost(Posts $post, Request $request, EntityManagerInterface $entityManager): Response
    {
        $form = $this->createForm(PostFormType::class, $post);
        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {
            $entityManager->flush();

            return $this->redirectToRoute('app_page_utilisateur', ['pseudo' => $this->getUser()->getPseudo()]);
        }

        return $this->render('post/modifier_post.html.twig', [
            'postForm' => $form->createView(),
        ]);
    }

    #[Route('/posts/supprimer/{id}', name: 'app_supprimer_post')]
    public function supprimerPost(Posts $post, EntityManagerInterface $entityManager): Response
    {
        $entityManager->remove($post);
        $entityManager->flush();

        return $this->redirectToRoute('app_page_utilisateur', ['pseudo' => $this->getUser()->getPseudo()]);
    }
}
