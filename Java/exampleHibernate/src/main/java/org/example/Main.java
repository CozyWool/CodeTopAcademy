package org.example;

import org.example.clinic.services.OwnerService;
import org.example.clinic.services.PetService;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class Main {

//    private final OwnerService ownerService;
//    private final PetService petService;
//
//    public Main(OwnerService ownerService, PetService petService) {
//        this.ownerService = ownerService;
//        this.petService = petService;
//    }

    public static void main(String[] args) {
        SpringApplication.run(Main.class, args);
    }
}