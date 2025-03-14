package org.example.clinic.services;

import org.example.clinic.models.Owner;
import org.example.clinic.repositories.OwnerRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class OwnerService {
    private final OwnerRepository ownerRepository;

    @Autowired
    public OwnerService(OwnerRepository ownerRepository) {
        this.ownerRepository = ownerRepository;
    }

    public List<Owner> getOwners() {
        return ownerRepository.findAll();
    }

    public Owner create(Owner owner) {
        return ownerRepository.save(owner);
    }

    public Owner update(Owner owner) {
        return ownerRepository.save(owner);
    }

    public void delete(Long id) {
        ownerRepository.deleteById(id);
    }

    public Owner getById(long id) {
        return ownerRepository.findById(id).orElse(null);
    }
}
