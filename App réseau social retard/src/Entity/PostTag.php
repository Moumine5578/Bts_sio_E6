<?php

namespace App\Entity;

use App\Repository\PostTagRepository;
use Doctrine\ORM\Mapping as ORM;

#[ORM\Entity(repositoryClass: PostTagRepository::class)]
class PostTag
{
    #[ORM\Id]
    #[ORM\GeneratedValue]
    #[ORM\Column]
    private ?int $id = null;

    #[ORM\ManyToOne(targetEntity: Posts::class)]
    #[ORM\JoinColumn(nullable: false)]
    private $post;

    #[ORM\ManyToOne(targetEntity: Tags::class)]
    #[ORM\JoinColumn(nullable: false)]
    private $tag;

    public function getId(): ?int
    {
        return $this->id;
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

    public function getTag(): ?Tags
    {
        return $this->tag;
    }

    public function setTag(?Tags $tag): self
    {
        $this->tag = $tag;

        return $this;
    }
}
