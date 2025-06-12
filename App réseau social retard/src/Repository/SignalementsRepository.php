<?php

namespace App\Repository;

use App\Entity\Signalements;
use Doctrine\Bundle\DoctrineBundle\Repository\ServiceEntityRepository;
use Doctrine\Persistence\ManagerRegistry;

/**
 * @extends ServiceEntityRepository<Signalements>
 *
 * @method Signalements|null find($id, $lockMode = null, $lockVersion = null)
 * @method Signalements|null findOneBy(array $criteria, array $orderBy = null)
 * @method Signalements[]    findAll()
 * @method Signalements[]    findBy(array $criteria, array $orderBy = null, $limit = null, $offset = null)
 */
class SignalementsRepository extends ServiceEntityRepository
{
    public function __construct(ManagerRegistry $registry)
    {
        parent::__construct($registry, Signalements::class);
    }

//    /**
//     * @return Signalements[] Returns an array of Signalements objects
//     */
//    public function findByExampleField($value): array
//    {
//        return $this->createQueryBuilder('s')
//            ->andWhere('s.exampleField = :val')
//            ->setParameter('val', $value)
//            ->orderBy('s.id', 'ASC')
//            ->setMaxResults(10)
//            ->getQuery()
//            ->getResult()
//        ;
//    }

//    public function findOneBySomeField($value): ?Signalements
//    {
//        return $this->createQueryBuilder('s')
//            ->andWhere('s.exampleField = :val')
//            ->setParameter('val', $value)
//            ->getQuery()
//            ->getOneOrNullResult()
//        ;
//    }
}
