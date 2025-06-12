<?php

namespace App\Entity;

use App\Repository\AbonnementsRepository;
use Doctrine\ORM\Mapping as ORM;

#[ORM\Entity(repositoryClass: AbonnementsRepository::class)]
class Abonnements
{
    #[ORM\Id]
    #[ORM\GeneratedValue]
    #[ORM\Column]
    private ?int $id = null;

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

    /**
     * @ORM\ManyToOne(targetEntity=Tags::class)
     * @ORM\JoinColumn(name="tag_id", referencedColumnName="id")
     */
    #[ORM\ManyToOne(targetEntity: Tags::class)]
    private ?Tags $tag = null;

    /**
     * @ORM\ManyToOne(targetEntity=User::class)
     * @ORM\JoinColumn(name="follow_utilisateur_id", referencedColumnName="id")
     */
    #[ORM\ManyToOne(targetEntity: User::class)]
    private ?User $followUtilisateur = null;

    public function getId(): ?int
    {
        return $this->id;
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

    public function getTag(): ?Tags
    {
        return $this->tag;
    }

    public function setTag(?Tags $tag): self
    {
        $this->tag = $tag;

        return $this;
    }

    public function getFollowUtilisateur(): ?User
    {
        return $this->followUtilisateur;
    }

    public function setFollowUtilisateur(?User $followUtilisateur): self
    {
        $this->followUtilisateur = $followUtilisateur;

        return $this;
    }
}