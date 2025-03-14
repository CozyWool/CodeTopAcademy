package org.example.clinic.controllers;

import org.example.clinic.models.Pet;
import org.example.clinic.services.PetService;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/pets")
public class PetController {

    private final PetService petService;

    public PetController(PetService petService){
        this.petService = petService;
    }
    @GetMapping
    public List<Pet> getAll() {
        return petService.getPets();
    }

    public Pet getById(@RequestParam long id) {
        return petService.getById(id);
    }

    @PostMapping
    public Pet createOwner(@RequestBody Pet pet) {
        return petService.create(pet);
    }


    @PutMapping("/{id}")
    public Pet updateOwner(@PathVariable Long id, @RequestBody Pet pet) {
        pet.setId(id);
        return petService.update(pet);
    }


    @DeleteMapping("/{id}")
    public void deleteOwner(@PathVariable Long id) {
        petService.delete(id);
    }
}
