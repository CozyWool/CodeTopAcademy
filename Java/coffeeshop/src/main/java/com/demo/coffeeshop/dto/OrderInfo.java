package com.demo.coffeeshop.dto;


import com.demo.coffeeshop.models.Clients;
import com.demo.coffeeshop.models.Orders;
import com.demo.coffeeshop.models.Personnel;

public class OrderInfo {
    private Clients client;
    private Personnel barista;
    private Orders order;

    public OrderInfo(Clients client, Personnel barista, Orders order) {
        this.client = client;
        this.barista = barista;
        this.order = order;
    }
    
    public Clients getClient() {
        return client;
    }

    public void setClient(Clients client) {
        this.client = client;
    }

    public Personnel getBarista() {
        return barista;
    }

    public void setBarista(Personnel barista) {
        this.barista = barista;
    }

    public Orders getOrder() {
        return order;
    }

    public void setOrder(Orders order) {
        this.order = order;
    }

    @Override
    public String toString() {
        return "Заказ: Клиент=" + client.getFullName() + 
               ", Бариста=" + barista.getFullName() + 
               ", Сумма=" + order.getTotalSum() + " руб.";
    }
}