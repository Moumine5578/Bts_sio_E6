<?php

namespace App\Repository;

use App\Entity\DemandeEtablissements;
use Doctrine\Bundle\DoctrineBundle\Repository\ServiceEntityRepository;
use Doctrine\Persistence\ManagerRegistry;

/**
 * @extends ServiceEntityRepository<DemandeEtablissements>
 *
 * @method DemandeEtablissements|null find($id, $lockMode = null, $lockVersion = null)
 * @method DemandeEtablissements|null findOneBy(array $criteria, array $orderBy = null)
 * @method DemandeEtablissements[]    findAll()
 * @method DemandeEtablissements[]    findBy(array $criteria, array $orderBy = null, $limit = null, $offset = null)
 */
class DemandeEtablissementsRepository extends ServiceEntityRepository
{
    public function __construct(ManagerRegistry $registry)
    {
        parent::__construct($registry, DemandeEtablissements::class);
    }

//    /**
//     * @return DemandeEtablissements[] Returns an array of DemandeEtablissements objects
//     */
//    public function findByExampleField($value): array
//    {
//        return $this->createQueryBuilder('d')
//            ->andWhere('d.exampleField = :val')
//            ->setParameter('val', $value)
//            ->orderBy('d.id', 'ASC')
//            ->setMaxResults(10)
//            ->getQuery()
//            ->getResult()
//        ;
//    }

//    public function findOneBySomeField($value): ?DemandeEtablissements
//    {
//        return $this->createQueryBuilder('d')
//            ->andWhere('d.exampleField = :val')
//            ->setParameter('val', $value)
//            ->getQuery()
//            ->getOneOrNullResult()
//        ;
//    }
}
