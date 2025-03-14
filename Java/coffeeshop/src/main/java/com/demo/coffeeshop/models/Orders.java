package com.demo.coffeeshop.models;

import java.sql.Date;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Table;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;

@Entity
@Table(name = "orders")
public class Orders implements java.io.Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @ManyToOne
    @JoinColumn(name = "client_id")
    private Clients clients;

    @ManyToOne
    @JoinColumn(name = "cafe_assortment_id")
    private CafeAssortment cafeAssortment;

    @Column(name = "created_at")
    private Date createdAt;

    @ManyToOne
    @JoinColumn(name = "personnel_id")
    private Personnel barista;

    @Column(name = "total_sum")
    private double totalSum;

    public Orders() {}

    public Orders(long id, Clients clients, CafeAssortment cafeAssortment, Date createdAt, Personnel barista, double totalSum) {
        this.id = id;
        this.clients = clients;
        this.cafeAssortment = cafeAssortment;
        this.createdAt = createdAt;
        this.barista = barista;
        this.totalSum = totalSum;
    }

    public long getId() {
        return this.id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public Clients getClients() {
        return this.clients;
    }

    public void setClients(Clients clients) {
        this.clients = clients;
    }

    public CafeAssortment getCafeAssortment() {
        return this.cafeAssortment;
    }

    public void setCafeAssortment(CafeAssortment cafeAssortment) {
        this.cafeAssortment = cafeAssortment;
    }

    public Date getCreatedAt() {
        return this.createdAt;
    }

    public void setCreatedAt(Date createdAt) {
        this.createdAt = createdAt;
    }

    public Personnel getBarista() {
        return this.barista;
    }

    public void setBarista(Personnel barista) {
        this.barista = barista;
    }

    public double getTotalSum() {
        return this.totalSum;
    }

    public void setTotalSum(double totalSum) {
        this.totalSum = totalSum;
    }

    @Override
    public String toString() {
        return "Заказ #" + id + ": " + cafeAssortment.getName() + ", Сумма: " + totalSum + " руб.";
    }
}