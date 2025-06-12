<?php

namespace App\Entity;

use App\Repository\LikesRepository;
use Doctrine\DBAL\Types\Types;
use Doctrine\ORM\Mapping as ORM;

#[ORM\Entity(repositoryClass: LikesRepository::class)]
class Likes
{
    #[ORM\Id]
    #[ORM\GeneratedValue]
    #[ORM\Column]
    private ?int $id = null;

    #[ORM\Column]
    private ?bool $super_like = null;

    #[ORM\Column(type: Types::DATETIME_MUTABLE, nullable: true)]
    private ?\DateTimeInterface $date_like = null;

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

    public function isSuperLike(): ?bool
    {
        return $this->super_like;
    }

    public function setSuperLike(bool $super_like): static
    {
        $this->super_like = $super_like;

        return $this;
    }

    public function getDateSuperLike(): ?\DateTimeInterface
    {
        return $this->date_like;
    }

    public function setDateSuperLike(?\DateTimeInterface $date_like): static
    {
        $this->date_like = $date_like;

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
