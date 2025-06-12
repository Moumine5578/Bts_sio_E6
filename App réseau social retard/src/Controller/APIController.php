<?php

namespace App\Controller;

use App\DTO\Periode_DTO;
use App\DTO\Compte_DTO;
use App\Entity\User;
use App\Entity\Likes;
use App\Entity\Posts;
use App\Entity\Commentaires;
use Doctrine\ORM\EntityManagerInterface;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Annotation\Route;
use OpenApi\Attributes as OA;

#[Route('/api')]
class APIController extends AbstractController
{
    public function __construct(private EntityManagerInterface $entityManager) {}

    #[Route('/GetNombreCreationsCompte', name: 'nombre_creations_compte', methods: ['POST'])]
    #[OA\Response(
        response: 200,
        description: 'Returns the number of accounts created within a specific period',
        content: new OA\JsonContent(type: 'integer')
    )]
    #[OA\RequestBody(
        required: true,
        content: new OA\JsonContent(ref: '#/components/schemas/Periode_DTO')
    )]
    public function GetNombreCreationsCompte(Periode_DTO $periode_DTO): Response
    {
        $userCount = $this->entityManager->getRepository(User::class)->count([
            'dateCreation' => $periode_DTO->dateDebut,
            'dateCreation' => $periode_DTO->dateFin
        ]);

        return $this->json($userCount);
    }

    #[Route('/GetNombreCreationsLike', name: 'nombre_creations_like', methods: ['POST'])]
    #[OA\Response(
        response: 200,
        description: 'Returns the number of likes created within a specific period',
        content: new OA\JsonContent(type: 'integer')
    )]
    #[OA\RequestBody(
        required: true,
        content: new OA\JsonContent(ref: '#/components/schemas/Periode_DTO')
    )]
    public function GetNombreCreationsLike(Periode_DTO $periode_DTO): Response
    {
        $likeCount = $this->entityManager->getRepository(Likes::class)->count([
            'dateLike' => $periode_DTO->dateDebut,
            'dateLike' => $periode_DTO->dateFin
        ]);

        return $this->json($likeCount);
    }

    #[Route('/GetNombreCreationsPost', name: 'nombre_creations_post', methods: ['POST'])]
    #[OA\Response(
        response: 200,
        description: 'Returns the number of posts created within a specific period',
        content: new OA\JsonContent(type: 'integer')
    )]
    #[OA\RequestBody(
        required: true,
        content: new OA\JsonContent(ref: '#/components/schemas/Periode_DTO')
    )]
    public function GetNombreCreationsPost(Periode_DTO $periode_DTO): Response
    {
        $postCount = $this->entityManager->getRepository(Posts::class)->count([
            'datePost' => $periode_DTO->dateDebut,
            'datePost' => $periode_DTO->dateFin
        ]);

        return $this->json($postCount);
    }

    #[Route('/GetNombreCreationsCommentaire', name: 'nombre_creations_commentaire', methods: ['POST'])]
    #[OA\Response(
        response: 200,
        description: 'Returns the number of comments created within a specific period',
        content: new OA\JsonContent(type: 'integer')
    )]
    #[OA\RequestBody(
        required: true,
        content: new OA\JsonContent(ref: '#/components/schemas/Periode_DTO')
    )]
    public function GetNombreCreationsCommentaire(Periode_DTO $periode_DTO): Response
    {
        $commentCount = $this->entityManager->getRepository(Commentaires::class)->count([
            'dateCommentaire' => $periode_DTO->dateDebut,
            'dateCommentaire' => $periode_DTO->dateFin
        ]);

        return $this->json($commentCount);
    }

    // Additional methods can be added here following the same pattern.
}
