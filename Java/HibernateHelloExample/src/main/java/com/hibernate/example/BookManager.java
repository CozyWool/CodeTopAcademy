package com.hibernate.example;

import jakarta.persistence.TypedQuery;
import jakarta.persistence.criteria.CriteriaBuilder;
import jakarta.persistence.criteria.CriteriaQuery;
import jakarta.persistence.criteria.Root;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.boot.Metadata;
import org.hibernate.boot.MetadataSources;
import org.hibernate.boot.registry.StandardServiceRegistry;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;

import java.util.List;

public class BookManager {
    private SessionFactory sessionFactory;

    private void init() {
        final StandardServiceRegistry registry = new StandardServiceRegistryBuilder()
                .configure().build();

        try {
            MetadataSources sources = new MetadataSources(registry);
            Metadata metadata = sources.getMetadataBuilder().build();

            sessionFactory = metadata.getSessionFactoryBuilder().build();
        } catch (Exception e) {
            StandardServiceRegistryBuilder.destroy(registry);
            e.printStackTrace();
        }
    }

    private void close() {
        if (sessionFactory != null) {
            sessionFactory.close();
        }
    }

    private void create() {
        Book book = new Book();
        book.setTitle("Java Hibernate 3");
        book.setAuthor("NNAuthor3");
        book.setPrice(750);

        Session session = sessionFactory.openSession();
        session.beginTransaction();
        session.save(book);
        session.getTransaction().commit();
        session.close();
    }

    private void read() {
        Session session = sessionFactory.openSession();
        long bookId = 2;
        Book book = session.get(Book.class, bookId);
        if (book != null) {
            System.out.println("Id: " + book.getId());
            System.out.println("Название: " + book.getTitle());
            System.out.println("Автор: " + book.getAuthor());
            System.out.println("Цена: " + book.getPrice());
        } else {
            System.out.println("❌ Книга не найдена");
        }
        session.close();
    }

    private void filter() {
        Session session = sessionFactory.openSession();

        CriteriaBuilder cb = session.getCriteriaBuilder();
        CriteriaQuery<Book> cq = cb.createQuery(Book.class);
        Root<Book> rootEntry = cq.from(Book.class);
        CriteriaQuery<Book> bookCriteriaQuery = cq.select(rootEntry).where(cb.like(rootEntry.get("author"), "richter"));

        TypedQuery<Book> query = session.createQuery(bookCriteriaQuery);
        List<Book> list = query.getResultList();

        for (Book book : list) {
            System.out.println("Id: " + book.getId());
            System.out.println("Название: " + book.getTitle());
            System.out.println("Автор: " + book.getAuthor());
            System.out.println("Цена: " + book.getPrice());
            System.out.println();
        }
        session.close();
    }

    private void sort() {
        Session session = sessionFactory.openSession();

        CriteriaBuilder cb = session.getCriteriaBuilder();
        CriteriaQuery<Book> cq = cb.createQuery(Book.class);
        Root<Book> rootEntry = cq.from(Book.class);
        CriteriaQuery<Book> bookCriteriaQuery = cq.select(rootEntry).orderBy(cb.desc(rootEntry.get("id")));

        TypedQuery<Book> query = session.createQuery(bookCriteriaQuery);
        List<Book> list = query.getResultList();

        for (Book book : list) {
            System.out.println("Id: " + book.getId());
            System.out.println("Название: " + book.getTitle());
            System.out.println("Автор: " + book.getAuthor());
            System.out.println("Цена: " + book.getPrice());
            System.out.println();
        }
        session.close();
    }

    private void update() {
        Session session = sessionFactory.openSession();
        long bookId = 1;
        Book book = session.get(Book.class, bookId);
        if (book != null) {
            book.setTitle("Измененное название");
            book.setAuthor("Измененное имя автора");
            book.setPrice(1250);
            session.beginTransaction();
            session.update(book);
            session.getTransaction().commit();
        } else {
            System.out.println("❌ Книга не найдена");
        }
        session.close();
    }

    private void delete() {

    }

    public static void main(String[] args) {
        BookManager manager = new BookManager();
        manager.init();

//        manager.create();
//        manager.read();
        System.out.println("\tFilter");
        manager.filter();
        System.out.println("\tSort");
        manager.sort();

        manager.close();
    }
}