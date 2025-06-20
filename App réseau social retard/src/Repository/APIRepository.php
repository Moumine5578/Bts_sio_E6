<?php

namespace App\Repository;

use App\Entity\API;
use Doctrine\Bundle\DoctrineBundle\Repository\ServiceEntityRepository;
use Doctrine\Persistence\ManagerRegistry;

/**
 * @extends ServiceEntityRepository<API>
 *
 * @method API|null find($id, $lockMode = null, $lockVersion = null)
 * @method API|null findOneBy(array $criteria, array $orderBy = null)
 * @method API[]    findAll()
 * @method API[]    findBy(array $criteria, array $orderBy = null, $limit = null, $offset = null)
 */
class APIRepository extends ServiceEntityRepository
{
    public function __construct(ManagerRegistry $registry)
    {
        parent::__construct($registry, API::class);
    }

//    /**
//     * @return API[] Returns an array of API objects
//     */
//    public function findByExampleField($value): array
//    {
//        return $this->createQueryBuilder('a')
//            ->andWhere('a.exampleField = :val')
//            ->setParameter('val', $value)
//            ->orderBy('a.id', 'ASC')
//            ->setMaxResults(10)
//            ->getQuery()
//            ->getResult()
//        ;
//    }

//    public function findOneBySomeField($value): ?API
//    {
//        return $this->createQueryBuilder('a')
//            ->andWhere('a.exampleField = :val')
//            ->setParameter('val', $value)
//            ->getQuery()
//            ->getOneOrNullResult()
//        ;
//    }
}
