<?php

namespace App\Entity;

use App\Repository\SignalementsRepository;
use Doctrine\ORM\Mapping as ORM;

#[ORM\Entity(repositoryClass: SignalementsRepository::class)]
class Signalements
{
    #[ORM\Id]
    #[ORM\GeneratedValue]
    #[ORM\Column]
    private ?int $id = null;

    #[ORM\Column(length: 255)]
    private ?string $descriptions_signalement = null;

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
     * @ORM\JoinColumn(name="utilisateur_signale_id", referencedColumnName="id")
     */
    #[ORM\ManyToOne(targetEntity: User::class)]
    private ?User $utilisateurSignale = null;

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getDescriptionsSignalement(): ?string
    {
        return $this->descriptions_signalement;
    }

    public function setDescriptionsSignalement(string $descriptions_signalement): static
    {
        $this->descriptions_signalement = $descriptions_signalement;

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

    public function getTag(): ?Tags
    {
        return $this->tag;
    }

    public function setTag(?Tags $tag): self
    {
        $this->tag = $tag;

        return $this;
    }

    public function getUtilisateurSignale(): ?User
    {
        return $this->utilisateurSignale;
    }

    public function setUtilisateurSignale(?User $utilisateurSignale): self
    {
        $this->utilisateurSignale = $utilisateurSignale;

        return $this;
    }
}
