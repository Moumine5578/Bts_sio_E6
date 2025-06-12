<?php

namespace App\Controller;

use App\Entity\Etablissement;
use Doctrine\Persistence\ManagerRegistry;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Annotation\Route;

class EtablissementController extends AbstractController
{
    #[Route('/etablissements', name: 'app_etablissements')]
    public function index(ManagerRegistry $doctrine): Response
    {
        $repo = $doctrine->getRepository(Etablissement::class);
        $etablissements = $repo->findBy([], ['nom' => 'ASC']);

        return $this->render('etablissement/index.html.twig', [
            'etablissements' => $etablissements,
        ]);
    }
}
