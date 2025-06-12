<?php

namespace App\Entity;

use App\Repository\CommentairesRepository;
use Doctrine\ORM\Mapping as ORM;
use Doctrine\DBAL\Types\Types;

#[ORM\Entity(repositoryClass: CommentairesRepository::class)]
class Commentaires
{
    #[ORM\Id]
    #[ORM\GeneratedValue]
    #[ORM\Column]
    private ?int $id = null;

    #[ORM\Column(length: 150)]
    private ?string $libelle_com = null;

    #[ORM\Column(type: Types::DATETIME_MUTABLE)]
    private ?\DateTimeInterface $date_com = null;

    /**
     * @ORM\ManyToOne(targetEntity=User::class)
     * @ORM\JoinColumn(name="utilisateur_id", referencedColumnName="id", nullable=false)
     */
    #[ORM\ManyToOne(targetEntity: User::class)]
    #[ORM\JoinColumn(nullable: false)]
    private ?User $utilisateur = null;

    /**
     * @ORM\ManyToOne(targetEntity=Posts::class)
     * @ORM\JoinColumn(name="post_id", referencedColumnName="id", nullable=false)
     */
    #[ORM\ManyToOne(targetEntity: Posts::class)]
    #[ORM\JoinColumn(nullable: false)]
    private ?Posts $post = null;

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getLibelleCom(): ?string
    {
        return $this->libelle_com;
    }

    public function setLibelleCom(string $libelle_com): static
    {
        $this->libelle_com = $libelle_com;

        return $this;
    }

    public function getDateCom(): ?\DateTimeInterface
    {
        return $this->date_com;
    }

    public function setDateCom(?\DateTimeInterface $date_com): self
    {
        $this->date_com = $date_com;
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

    public function getPost(): ?Posts
    {
        return $this->post;
    }

    public function setPost(?Posts $post): self
    {
        $this->post = $post;

        return $this;
    }
}
