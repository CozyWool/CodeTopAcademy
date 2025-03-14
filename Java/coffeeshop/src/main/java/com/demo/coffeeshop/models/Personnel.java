package com.demo.coffeeshop.models;

import java.util.HashSet;
import java.util.Set;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Table;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;

@Entity
@Table(name = "personnel")
public class Personnel implements java.io.Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @Column(name = "full_name")
    private String fullName;

    @Column(name = "contact_phone")
    private String contactPhone;

    @Column(name = "contact_mail_address")
    private String contactMailAddress;

    @Column(name = "position")
    private String position;

    @OneToMany(mappedBy = "personnel")
    private Set<PersonnelSchedule> personnelSchedules = new HashSet<>();

    public Personnel() {}

    public Personnel(String position) {
        this.position = position;
    }

    public Personnel(long id, String fullName, String contactPhone, String contactMailAddress, String position) {
        this.id = id;
        this.fullName = fullName;
        this.contactPhone = contactPhone;
        this.contactMailAddress = contactMailAddress;
        this.position = position;
    }

    public Personnel(long id, String fullName, String contactPhone, String contactMailAddress, String position,
                     Set personnelSchedules) {
        this.id = id;
        this.fullName = fullName;
        this.contactPhone = contactPhone;
        this.contactMailAddress = contactMailAddress;
        this.position = position;
        this.personnelSchedules = personnelSchedules;
    }

    public long getId() {
        return this.id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getFullName() {
        return this.fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public String getContactPhone() {
        return this.contactPhone;
    }

    public void setContactPhone(String contactPhone) {
        this.contactPhone = contactPhone;
    }

    public String getContactMailAddress() {
        return this.contactMailAddress;
    }

    public void setContactMailAddress(String contactMailAddress) {
        this.contactMailAddress = contactMailAddress;
    }

    public String getPosition() {
        return this.position;
    }

    public void setPosition(String position) {
        this.position = position;
    }

    public Set getPersonnelSchedules() {
        return this.personnelSchedules;
    }

    public void setPersonnelSchedules(Set personnelSchedules) {
        this.personnelSchedules = personnelSchedules;
    }

    @Override
    public String toString() {
        return fullName + " (" + position + ")";
    }
}