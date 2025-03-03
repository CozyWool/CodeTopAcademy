package com.example.coffee.demo;

import org.hibernate.SessionFactory;
import org.hibernate.boot.Metadata;
import org.hibernate.boot.MetadataSources;
import org.hibernate.boot.registry.StandardServiceRegistry;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;


@SpringBootApplication
public class DemoApplication {
	private static SessionFactory sessionFactory;

	private static void init() {
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

	private static void close() {
		if (sessionFactory != null) {
			sessionFactory.close();
		}
	}

	public static void task1() {
//		var coffee = new Order();
//		var client = new Client();
//		client.setId(1L);
//		var cafe = new CafeAssortment();
//		cafe.setId(1L);
//
//		coffee.setClient(client);
//		coffee.setCafeAssortment(cafe);
//
//		var dessert = new Order();
//
//		var client2 = new Client();
//		client.setId(1L);
//		var cafe2 = new CafeAssortment();
//		cafe.setId(1L);
//		dessert.setClient(client2);
//		dessert.setCafeAssortment(cafe2);
//
//		var session = sessionFactory.openSession();
//		session.beginTransaction();
//		session.save(coffee);
//		session.save(dessert);
//		session.getTransaction().commit();
//		session.close();
	}


	public static void main(String[] args) {
		init();
		task1();
		close();
		SpringApplication.run(DemoApplication.class, args);

	}

}



