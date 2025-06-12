<?php

namespace App\Repository;

use App\Entity\PageEtablissementController;
use Doctrine\Bundle\DoctrineBundle\Repository\ServiceEntityRepository;
use Doctrine\Persistence\ManagerRegistry;

/**
 * @extends ServiceEntityRepository<PageEtablissementController>
 *
 * @method PageEtablissementController|null find($id, $lockMode = null, $lockVersion = null)
 * @method PageEtablissementController|null findOneBy(array $criteria, array $orderBy = null)
 * @method PageEtablissementController[]    findAll()
 * @method PageEtablissementController[]    findBy(array $criteria, array $orderBy = null, $limit = null, $offset = null)
 */
class PageEtablissementControllerRepository extends ServiceEntityRepository
{
    public function __construct(ManagerRegistry $registry)
    {
        parent::__construct($registry, PageEtablissementController::class);
    }

//    /**
//     * @return PageEtablissementController[] Returns an array of PageEtablissementController objects
//     */
//    public function findByExampleField($value): array
//    {
//        return $this->createQueryBuilder('p')
//            ->andWhere('p.exampleField = :val')
//            ->setParameter('val', $value)
//            ->orderBy('p.id', 'ASC')
//            ->setMaxResults(10)
//            ->getQuery()
//            ->getResult()
//        ;
//    }

//    public function findOneBySomeField($value): ?PageEtablissementController
//    {
//        return $this->createQueryBuilder('p')
//            ->andWhere('p.exampleField = :val')
//            ->setParameter('val', $value)
//            ->getQuery()
//            ->getOneOrNullResult()
//        ;
//    }
}
