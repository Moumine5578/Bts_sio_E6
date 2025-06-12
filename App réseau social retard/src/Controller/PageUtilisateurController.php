<?php

namespace App\Controller;

use App\Entity\User;
use App\Entity\Posts;
use App\Entity\Abonnements;
use App\Form\RegistrationFormType;
use Doctrine\ORM\EntityManagerInterface;
use Doctrine\Persistence\ManagerRegistry;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\PasswordHasher\Hasher\UserPasswordHasherInterface;
use Symfony\Component\Routing\Annotation\Route;

class PageUtilisateurController extends AbstractController
{
    public function __construct(private EntityManagerInterface $entityManager) {}

    #[Route('/page/{pseudo}', name: 'app_page_utilisateur')]
    public function index(string $pseudo, ManagerRegistry $doctrine): Response
    {
        // Récupérer le référentiel (repository) de l'entité User
        $userRepository = $doctrine->getRepository(User::class);

        // Rechercher l'utilisateur par pseudo
        $utilisateur = $userRepository->findOneBy(['pseudo' => $pseudo]);

        //on récupère le nombre de posts de l'utilisateur
        $nbposts = $this->entityManager->getRepository(Posts::class)->count(['utilisateur' => $utilisateur]);

        //on récupère le nombre de followers de l'utilisateur
        $nbfollowers = $this->entityManager->getRepository(Abonnements::class)->count(['followUtilisateur' => $utilisateur]);

        //on récupère le nombre de personnes suivies de l'utilisateur
        $nbsuivi = $this->entityManager->getRepository(Abonnements::class)->count(['utilisateur' => $utilisateur]);

        $repo = $doctrine->getRepository(Posts::class);
        $posts = $repo->findBy(['utilisateur' => $utilisateur]);

        // Vérifier si l'utilisateur existe
        if (!$utilisateur) {
            // Redirection vers une page d'erreur ou une autre action
            throw $this->createNotFoundException('L\'utilisateur n\'existe pas.');
        }

        // L'utilisateur existe, rendre la page
        return $this->render('page_utilisateur/index.html.twig', [
            'controller_name' => 'PageUtilisateurController',
            'utilisateur' => $utilisateur,
            'posts' => $posts,
            'nbposts' => $nbposts,
            'nbfollowers' => $nbfollowers,
            'nbsuivi' => $nbsuivi
        ]);
    }

    #[Route('/page/{id}/modifier', name: 'app_modifier_utilisateur')]
    public function modifier(User $user, Request $request, UserPasswordHasherInterface $userPasswordHasher, EntityManagerInterface $entityManager): Response
    {
        $form = $this->createForm(RegistrationFormType::class, $user);
        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {
            // encode the plain password
            $user->setPassword(
                $userPasswordHasher->hashPassword(
                    $user,
                    $form->get('plainPassword')->getData()
                )
            );
            $entityManager->flush();

            return $this->redirectToRoute('app_page_utilisateur', ['pseudo' => $this->getUser()->getPseudo()]);
        }

        return $this->render('page_utilisateur/modifier_profil.html.twig', [
            'userForm' => $form->createView(),
        ]);
    }
}
