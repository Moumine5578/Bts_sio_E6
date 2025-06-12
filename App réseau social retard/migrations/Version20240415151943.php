<?php

declare(strict_types=1);

namespace DoctrineMigrations;

use Doctrine\DBAL\Schema\Schema;
use Doctrine\Migrations\AbstractMigration;

/**
 * Auto-generated Migration: Please modify to your needs!
 */
final class Version20240415151943 extends AbstractMigration
{
    public function getDescription(): string
    {
        return '';
    }

    public function up(Schema $schema): void
    {
        // this up() migration is auto-generated, please modify it to your needs
        $this->addSql('CREATE TABLE abonnements (id INT AUTO_INCREMENT NOT NULL, utilisateur_id INT NOT NULL, etablissement_id INT DEFAULT NULL, tag_id INT DEFAULT NULL, follow_utilisateur_id INT DEFAULT NULL, INDEX IDX_4788B767FB88E14F (utilisateur_id), INDEX IDX_4788B767FF631228 (etablissement_id), INDEX IDX_4788B767BAD26311 (tag_id), INDEX IDX_4788B767902683C9 (follow_utilisateur_id), PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE commentaires (id INT AUTO_INCREMENT NOT NULL, utilisateur_id INT NOT NULL, post_id INT NOT NULL, libelle_com VARCHAR(150) NOT NULL, INDEX IDX_D9BEC0C4FB88E14F (utilisateur_id), INDEX IDX_D9BEC0C44B89032C (post_id), PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE demande_etablissement (id INT AUTO_INCREMENT NOT NULL, utilisateur_id INT NOT NULL, nom VARCHAR(255) NOT NULL, adresse VARCHAR(255) NOT NULL, description VARCHAR(255) NOT NULL, INDEX IDX_907A089CFB88E14F (utilisateur_id), PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE etablissement (id INT AUTO_INCREMENT NOT NULL, nom VARCHAR(255) NOT NULL, description VARCHAR(255) NOT NULL, adresse VARCHAR(255) NOT NULL, PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE likes (id INT AUTO_INCREMENT NOT NULL, utilisateur_id INT NOT NULL, post_id INT NOT NULL, super_like TINYINT(1) NOT NULL, date_super_like DATETIME DEFAULT NULL, INDEX IDX_49CA4E7DFB88E14F (utilisateur_id), INDEX IDX_49CA4E7D4B89032C (post_id), PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE photos (id INT AUTO_INCREMENT NOT NULL, utilisateur_id INT DEFAULT NULL, etablissement_id INT DEFAULT NULL, photo VARCHAR(255) NOT NULL, INDEX IDX_876E0D9FB88E14F (utilisateur_id), INDEX IDX_876E0D9FF631228 (etablissement_id), PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE post_tag (id INT AUTO_INCREMENT NOT NULL, post_id INT NOT NULL, tag_id INT NOT NULL, INDEX IDX_5ACE3AF04B89032C (post_id), INDEX IDX_5ACE3AF0BAD26311 (tag_id), PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE posts (id INT AUTO_INCREMENT NOT NULL, utilisateur_id INT NOT NULL, etablissement_id INT DEFAULT NULL, titre VARCHAR(100) NOT NULL, description_post VARCHAR(255) NOT NULL, date_post DATETIME NOT NULL, temps_retards INT NOT NULL, INDEX IDX_885DBAFAFB88E14F (utilisateur_id), INDEX IDX_885DBAFAFF631228 (etablissement_id), PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE signalements (id INT AUTO_INCREMENT NOT NULL, utilisateur_id INT NOT NULL, etablissement_id INT DEFAULT NULL, tag_id INT DEFAULT NULL, utilisateur_signale_id INT DEFAULT NULL, descriptions_signalement VARCHAR(255) NOT NULL, INDEX IDX_120AE27FB88E14F (utilisateur_id), INDEX IDX_120AE27FF631228 (etablissement_id), INDEX IDX_120AE27BAD26311 (tag_id), INDEX IDX_120AE2737B960BE (utilisateur_signale_id), PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE tags (id INT AUTO_INCREMENT NOT NULL, libelle_tag VARCHAR(255) NOT NULL, PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE user (id INT AUTO_INCREMENT NOT NULL, etablissement_id INT DEFAULT NULL, pseudo VARCHAR(255) NOT NULL, biographie VARCHAR(255) DEFAULT NULL, email VARCHAR(180) NOT NULL, roles JSON NOT NULL COMMENT \'(DC2Type:json)\', password VARCHAR(255) NOT NULL, photo_profil VARCHAR(255) NOT NULL, est_actif TINYINT(1) NOT NULL, date_creation DATETIME NOT NULL, UNIQUE INDEX UNIQ_8D93D649E7927C74 (email), INDEX IDX_8D93D649FF631228 (etablissement_id), PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE messenger_messages (id BIGINT AUTO_INCREMENT NOT NULL, body LONGTEXT NOT NULL, headers LONGTEXT NOT NULL, queue_name VARCHAR(190) NOT NULL, created_at DATETIME NOT NULL COMMENT \'(DC2Type:datetime_immutable)\', available_at DATETIME NOT NULL COMMENT \'(DC2Type:datetime_immutable)\', delivered_at DATETIME DEFAULT NULL COMMENT \'(DC2Type:datetime_immutable)\', INDEX IDX_75EA56E0FB7336F0 (queue_name), INDEX IDX_75EA56E0E3BD61CE (available_at), INDEX IDX_75EA56E016BA31DB (delivered_at), PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('ALTER TABLE abonnements ADD CONSTRAINT FK_4788B767FB88E14F FOREIGN KEY (utilisateur_id) REFERENCES user (id)');
        $this->addSql('ALTER TABLE abonnements ADD CONSTRAINT FK_4788B767FF631228 FOREIGN KEY (etablissement_id) REFERENCES etablissement (id)');
        $this->addSql('ALTER TABLE abonnements ADD CONSTRAINT FK_4788B767BAD26311 FOREIGN KEY (tag_id) REFERENCES tags (id)');
        $this->addSql('ALTER TABLE abonnements ADD CONSTRAINT FK_4788B767902683C9 FOREIGN KEY (follow_utilisateur_id) REFERENCES user (id)');
        $this->addSql('ALTER TABLE commentaires ADD CONSTRAINT FK_D9BEC0C4FB88E14F FOREIGN KEY (utilisateur_id) REFERENCES user (id)');
        $this->addSql('ALTER TABLE commentaires ADD CONSTRAINT FK_D9BEC0C44B89032C FOREIGN KEY (post_id) REFERENCES posts (id)');
        $this->addSql('ALTER TABLE demande_etablissement ADD CONSTRAINT FK_907A089CFB88E14F FOREIGN KEY (utilisateur_id) REFERENCES user (id)');
        $this->addSql('ALTER TABLE likes ADD CONSTRAINT FK_49CA4E7DFB88E14F FOREIGN KEY (utilisateur_id) REFERENCES user (id)');
        $this->addSql('ALTER TABLE likes ADD CONSTRAINT FK_49CA4E7D4B89032C FOREIGN KEY (post_id) REFERENCES posts (id)');
        $this->addSql('ALTER TABLE photos ADD CONSTRAINT FK_876E0D9FB88E14F FOREIGN KEY (utilisateur_id) REFERENCES user (id)');
        $this->addSql('ALTER TABLE photos ADD CONSTRAINT FK_876E0D9FF631228 FOREIGN KEY (etablissement_id) REFERENCES etablissement (id)');
        $this->addSql('ALTER TABLE post_tag ADD CONSTRAINT FK_5ACE3AF04B89032C FOREIGN KEY (post_id) REFERENCES posts (id)');
        $this->addSql('ALTER TABLE post_tag ADD CONSTRAINT FK_5ACE3AF0BAD26311 FOREIGN KEY (tag_id) REFERENCES tags (id)');
        $this->addSql('ALTER TABLE posts ADD CONSTRAINT FK_885DBAFAFB88E14F FOREIGN KEY (utilisateur_id) REFERENCES user (id)');
        $this->addSql('ALTER TABLE posts ADD CONSTRAINT FK_885DBAFAFF631228 FOREIGN KEY (etablissement_id) REFERENCES etablissement (id)');
        $this->addSql('ALTER TABLE signalements ADD CONSTRAINT FK_120AE27FB88E14F FOREIGN KEY (utilisateur_id) REFERENCES user (id)');
        $this->addSql('ALTER TABLE signalements ADD CONSTRAINT FK_120AE27FF631228 FOREIGN KEY (etablissement_id) REFERENCES etablissement (id)');
        $this->addSql('ALTER TABLE signalements ADD CONSTRAINT FK_120AE27BAD26311 FOREIGN KEY (tag_id) REFERENCES tags (id)');
        $this->addSql('ALTER TABLE signalements ADD CONSTRAINT FK_120AE2737B960BE FOREIGN KEY (utilisateur_signale_id) REFERENCES user (id)');
        $this->addSql('ALTER TABLE user ADD CONSTRAINT FK_8D93D649FF631228 FOREIGN KEY (etablissement_id) REFERENCES etablissement (id)');
    }

    public function down(Schema $schema): void
    {
        // this down() migration is auto-generated, please modify it to your needs
        $this->addSql('ALTER TABLE abonnements DROP FOREIGN KEY FK_4788B767FB88E14F');
        $this->addSql('ALTER TABLE abonnements DROP FOREIGN KEY FK_4788B767FF631228');
        $this->addSql('ALTER TABLE abonnements DROP FOREIGN KEY FK_4788B767BAD26311');
        $this->addSql('ALTER TABLE abonnements DROP FOREIGN KEY FK_4788B767902683C9');
        $this->addSql('ALTER TABLE commentaires DROP FOREIGN KEY FK_D9BEC0C4FB88E14F');
        $this->addSql('ALTER TABLE commentaires DROP FOREIGN KEY FK_D9BEC0C44B89032C');
        $this->addSql('ALTER TABLE demande_etablissement DROP FOREIGN KEY FK_907A089CFB88E14F');
        $this->addSql('ALTER TABLE likes DROP FOREIGN KEY FK_49CA4E7DFB88E14F');
        $this->addSql('ALTER TABLE likes DROP FOREIGN KEY FK_49CA4E7D4B89032C');
        $this->addSql('ALTER TABLE photos DROP FOREIGN KEY FK_876E0D9FB88E14F');
        $this->addSql('ALTER TABLE photos DROP FOREIGN KEY FK_876E0D9FF631228');
        $this->addSql('ALTER TABLE post_tag DROP FOREIGN KEY FK_5ACE3AF04B89032C');
        $this->addSql('ALTER TABLE post_tag DROP FOREIGN KEY FK_5ACE3AF0BAD26311');
        $this->addSql('ALTER TABLE posts DROP FOREIGN KEY FK_885DBAFAFB88E14F');
        $this->addSql('ALTER TABLE posts DROP FOREIGN KEY FK_885DBAFAFF631228');
        $this->addSql('ALTER TABLE signalements DROP FOREIGN KEY FK_120AE27FB88E14F');
        $this->addSql('ALTER TABLE signalements DROP FOREIGN KEY FK_120AE27FF631228');
        $this->addSql('ALTER TABLE signalements DROP FOREIGN KEY FK_120AE27BAD26311');
        $this->addSql('ALTER TABLE signalements DROP FOREIGN KEY FK_120AE2737B960BE');
        $this->addSql('ALTER TABLE user DROP FOREIGN KEY FK_8D93D649FF631228');
        $this->addSql('DROP TABLE abonnements');
        $this->addSql('DROP TABLE commentaires');
        $this->addSql('DROP TABLE demande_etablissement');
        $this->addSql('DROP TABLE etablissement');
        $this->addSql('DROP TABLE likes');
        $this->addSql('DROP TABLE photos');
        $this->addSql('DROP TABLE post_tag');
        $this->addSql('DROP TABLE posts');
        $this->addSql('DROP TABLE signalements');
        $this->addSql('DROP TABLE tags');
        $this->addSql('DROP TABLE user');
        $this->addSql('DROP TABLE messenger_messages');
    }
}
