<?php

namespace App\Entity;

use App\Repository\PostsRepository;
use Doctrine\DBAL\Types\Types;
use Doctrine\ORM\Mapping as ORM;

#[ORM\Entity(repositoryClass: PostsRepository::class)]
class Posts
{
    #[ORM\Id]
    #[ORM\GeneratedValue]
    #[ORM\Column]
    private ?int $id = null;

    #[ORM\Column(length: 100)]
    private ?string $titre = null;

    #[ORM\Column(length: 255)]
    private ?string $description_post = null;

    #[ORM\Column(type: Types::DATETIME_MUTABLE)]
    private ?\DateTimeInterface $date_post = null;

    #[ORM\Column]
    private ?int $tempsRetards = null;

    /**
     * @ORM\ManyToOne(targetEntity=User::class)
     * @ORM\JoinColumn(name="utilisateur_id", referencedColumnName="id", nullable=false)
     */
    #[ORM\ManyToOne(targetEntity: User::class)]
    #[ORM\JoinColumn(nullable: false)]
    private ?User $utilisateur = null;

    /**
     * @ORM\ManyToOne(targetEntity=Etablissement::class)
     * @ORM\JoinColumn(name="etablissement_id", referencedColumnName="id")
     */
    #[ORM\ManyToOne(targetEntity: Etablissement::class)]
    private ?Etablissement $etablissement = null;

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getTitre(): ?string
    {
        return $this->titre;
    }

    public function setTitre(string $titre): static
    {
        $this->titre = $titre;

        return $this;
    }

    public function getDescriptionPost(): ?string
    {
        return $this->description_post;
    }

    public function setDescriptionPost(string $description_post): static
    {
        $this->description_post = $description_post;

        return $this;
    }

    public function getDatePost(): ?\DateTimeInterface
    {
        return $this->date_post;
    }

    public function setDatePost(\DateTimeInterface $date_post): static
    {
        $this->date_post = $date_post;

        return $this;
    }

    public function getTempsRetards(): ?int
    {
        return $this->tempsRetards;
    }

    public function setTempsRetards(int $tempsRetards): static
    {
        $this->tempsRetards = $tempsRetards;

        return $this;
    }

    public function getUtilisateur(): ?User
    {
        return $this->utilisateur;
    }

    public function setUtilisateur(?User $utilisateur): self
    {
        $this->utilisateur = $utilisateur;

        return $this;
    }

    public function getEtablissement(): ?Etablissement
    {
        return $this->etablissement;
    }

    public function setEtablissement(?Etablissement $etablissement): self
    {
        $this->etablissement = $etablissement;

        return $this;
    }
}
