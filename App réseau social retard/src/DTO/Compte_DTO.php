<?php

namespace App\DTO;
use OpenApi\Attributes as OA;

#[OA\Schema(
    title: "Compte_DTO",
    description: "Schéma de données pour un compte utilisateur",
    required: ["pseudo", "nombrePosts", "nombreCommentaires"]
)]
class Compte_DTO
{
    /**
     * @OA\Property(
     *     description="Pseudo de l'utilisateur",
     *     type="string"
     * )
     */
    public string $pseudo;

    /**
     * @OA\Property(
     *     description="Nombre de posts de l'utilisateur",
     *     type="integer"
     * )
     */
    public int $nombrePosts;

    /**
     * @OA\Property(
     *     description="Nombre de commentaires de l'utilisateur",
     *     type="integer"
     * )
     */
    public int $nombreCommentaires;
}