<?php

namespace App\Entity;

use App\Repository\TagsRepository;
use Doctrine\ORM\Mapping as ORM;

#[ORM\Entity(repositoryClass: TagsRepository::class)]
class Tags
{
    #[ORM\Id]
    #[ORM\GeneratedValue]
    #[ORM\Column]
    private ?int $id = null;

    #[ORM\Column(length: 255)]
    private ?string $libelle_tag = null;

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getLibelleTag(): ?string
    {
        return $this->libelle_tag;
    }

    public function setLibelleTag(string $libelle_tag): static
    {
        $this->libelle_tag = $libelle_tag;

        return $this;
    }
}
