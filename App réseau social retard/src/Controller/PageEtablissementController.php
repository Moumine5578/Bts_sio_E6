<?php

namespace App\Controller;

use App\Entity\Etablissement;
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

class PageEtablissementController extends AbstractController
{
    public function __construct(private EntityManagerInterface $entityManager) {}

    #[Route('/etablissement/{nom}', name: 'app_page_etablissement')]
    public function index(string $nom, ManagerRegistry $doctrine): Response
    {
        // Récupérer le référentiel (repository) de l'entité Etablissement
        $etablissementRepository = $doctrine->getRepository(Etablissement::class);

        // Rechercher l'etablissement par son nom
        $etablissement = $etablissementRepository->findOneBy(['nom' => $nom]);

        //on récupère le nombre d'utilisateur de l'établissement
        $nbusers = $this->entityManager->getRepository(User::class)->count(['etablissement' => $etablissement]);

        $repo = $doctrine->getRepository(Posts::class);
        $posts = $repo->findBy(['etablissement' => $etablissement]);

        // Vérifier si l'utilisateur existe
        if (!$etablissement) {
            // Redirection vers une page d'erreur ou une autre action
            throw $this->createNotFoundException('L\'établissement n\'existe pas.');
        }

        // L'utilisateur existe, rendre la page
        return $this->render('page_etablissement/index.html.twig', [
            'etablissement' => $etablissement,
            'posts' => $posts,
            'nbusers' => $nbusers
        ]);
    }
}
