package org.example.clinic.services;

import org.example.clinic.models.Owner;
import org.example.clinic.models.Pet;
import org.example.clinic.repositories.PetRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class PetService {


    private final PetRepository petRepository;

    @Autowired
    public PetService(PetRepository petRepository) {
        this.petRepository = petRepository;
    }

    public List<Pet> getPets() {
        return petRepository.findAll();
    }

    public Pet create(Pet pet) {
        return petRepository.save(pet);
    }

    public Pet update(Pet pet) {
        return petRepository.save(pet);
    }

    public void delete(Long id) {
        petRepository.deleteById(id);
    }

    public Pet getById(long id) {
        return petRepository.findById(id).orElse(null);
    }
}
