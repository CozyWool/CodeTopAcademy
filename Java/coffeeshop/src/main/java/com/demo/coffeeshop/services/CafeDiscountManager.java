package com.demo.coffeeshop.services;

import com.demo.coffeeshop.dto.*;
import com.demo.coffeeshop.models.*;
import jakarta.persistence.EntityManager;
import jakarta.persistence.PersistenceContext;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.sql.Date;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Objects;
import java.util.stream.Collectors;

@Service
public class CafeDiscountManager {
    
    @PersistenceContext
    private EntityManager entityManager;

    public List<Clients> getClientsWithMinimumDiscount() {
        List<Clients> clients = getClients();
        List<Integer> discounts = getDiscounts(clients);

        int minDiscount = getDiscount(discounts, true);

        return clients.stream().filter(client -> client.getDiscount() == minDiscount).collect(Collectors.toList());
    }

    public List<Clients> getClientsWithMaximumDiscount() {
        List<Clients> clients = getClients();
        List<Integer> discounts = getDiscounts(clients);

        int maxDiscount = getDiscount(discounts, false);

        return clients.stream().filter(client -> client.getDiscount() == maxDiscount).collect(Collectors.toList());
    }

    public double getAverageDiscount() {
        List<Clients> clients = getClients();
        List<Integer> discounts = getDiscounts(clients);

        return discounts.stream().mapToDouble(Integer::doubleValue).average().orElse(0);
    }
    
    public Clients getYoungestClient() {
        List<Clients> clients = getClients();
        
        Date youngestBirthDate = getAge(clients, true);  
        return clients.stream().filter(client -> client.getBirthDate().equals(youngestBirthDate)).findFirst().orElse(null);
    }

    public Clients getOldestClient() {
        List<Clients> clients = getClients();
        
        Date oldestBirthDate = getAge(clients, false);
        
        return clients.stream().filter(client -> client.getBirthDate().equals(oldestBirthDate)).findFirst().orElse(null);
    }

    public Clients getClientWithBirthdayToday() {
        List<Clients> clients = getClients();
        
        Date today = new Date(System.currentTimeMillis());
        
        return clients.stream().filter(client -> client.getBirthDate().equals(today)).findFirst().orElse(null);
    }

    public Clients getClientWithEmptyContactInfo() {
        List<Clients> clients = getClients();

        return clients.stream().filter(client -> client.getContactMailAddress() == null).findFirst().orElse(null);
    }

    public Orders getOrderInCurrentDate(Date date) {
        List<Orders> orders = getOrders();

        return orders.stream().filter(order -> order.getCreatedAt().equals(date)).findFirst().orElse(null);
    }

    public long getOrderCountForPositionInDate(String type, Date date) {
        List<Orders> orders = getOrders();

        return orders.stream().filter(order -> order.getCreatedAt().equals(date) && order.getCafeAssortment().getType().equals(type)).count();
    }

    @Transactional(readOnly = true)
    public List<OrderInfo> getClientsAndBaristasForTodays(String type) {
        try {
            List<OrderInfo> orderInfos = new ArrayList<>();
            Date today = Date.valueOf(LocalDate.now());

            List<Orders> orders = entityManager.createQuery("FROM Orders", Orders.class).getResultList();
            
            for (Orders order : orders) {
                if (order.getCreatedAt().equals(today) && 
                    order.getCafeAssortment().getType().equals(type)) {
                    OrderInfo orderInfo = new OrderInfo(
                        order.getClients(),
                        order.getBarista(),
                        order
                    );
                    orderInfos.add(orderInfo);
                }
            }

            return orderInfos;
        } catch (Exception e) {
            throw new RuntimeException("❌ Ошибка при получении заказов", e);
        }
    }

    public float getAverageOrderPriceInCurrentDate(Date date) {
        List<Orders> orders = getOrdersInDateRange(date, date);
        
        float totalPrice = (float)orders.stream().mapToDouble(order -> order.getTotalSum()).sum();

        return totalPrice / orders.size();
    }

    public double getMaximumSumOfOrderInCurrentDate(Date date) {
        List<Orders> orders = getOrdersInDateRange(date, date);

        return getMaximumSumOfOrder(orders);
    }

    public Clients getClientsWithMaximumSumOfOrderInCurrentDate(Date date) {
        List<Orders> orders = getOrdersInDateRange(date, date);
        
        double maxPrice = getMaximumSumOfOrder(orders);

        return orders.stream().filter(order -> order.getTotalSum() == maxPrice).findFirst().orElse(null).getClients();
    }

    public List<PersonnelSchedule> getBaristaSchedule(Personnel barista, String baristaName) {
        List<PersonnelSchedule> schedules = getPersonnelSchedules();

        try {
            List<PersonnelSchedule> baristaSchedules = schedules.stream().filter(schedule -> 
                schedule.getPersonnel().getFullName().equals(baristaName) && schedule.getPersonnel().getPosition().equals(barista.getPosition())
            ).collect(Collectors.toList());

            if (isEmpty(baristaSchedules)) {
                throw new RuntimeException("❌ Расписания нет");
            } 
            return baristaSchedules;
        } catch (Exception e) {
            throw new RuntimeException("❌ Ошибка при получении расписаний", e);
        }
    }
    
    public List<PersonnelSchedule> getBaristasSchedule(Personnel barista){
        List<PersonnelSchedule> schedules = getPersonnelSchedules();

        try{
           List<PersonnelSchedule> baristaSchedules = schedules.stream().filter(schedule -> schedule.getPersonnel().getPosition().equals(barista.getPosition())).collect(Collectors.toList());

           if (isEmpty(baristaSchedules)) {
               throw new RuntimeException("❌ Расписания нет");
           }
            return baristaSchedules;
        } catch (Exception e) {
            throw new RuntimeException("❌ Ошибка при получении расписаний", e);
        }
    }

    public List<PersonnelWithSchedule> getPersonnelScheduleForWeek() {
        List<PersonnelSchedule> schedules = getPersonnelSchedules();
        List<Personnel> allPersonnel = getPersonnel();
        
        try {
            List<PersonnelWithSchedule> personnelWithSchedules = new ArrayList<>();

            for(Personnel person : allPersonnel) {
                List<PersonnelSchedule> personSchedules = schedules.stream()
                    .filter(schedule -> schedule.getPersonnel().getId() == person.getId())
                    .collect(Collectors.toList());
                personnelWithSchedules.add(new PersonnelWithSchedule(person, personSchedules));
            }
            
            if (isEmpty(personnelWithSchedules)) {
                throw new RuntimeException("❌ Расписания нет");
            }

            return personnelWithSchedules;
        } catch (Exception e) {
            throw new RuntimeException("❌ Ошибка при получении расписаний", e);
        }
    }

    @Transactional(readOnly = true)
    private List<Clients> getClients() {
        try{
            List<Clients> clients = entityManager.createQuery("FROM Clients", Clients.class).getResultList();
            if (isEmpty(clients)) {
                throw new RuntimeException("❌ Клиентов нет");
            }
            return clients;
        } catch (Exception e) {
            throw new RuntimeException("❌ Ошибка при получении клиентов", e);
        }
    }

    @Transactional(readOnly = true)
    private List<Orders> getOrders() {
        try{
            List<Orders> orders = entityManager.createQuery("FROM Orders", Orders.class).getResultList();
            if (isEmpty(orders)) {
                throw new RuntimeException("❌ Заказов нет");
            }
            return orders;
        } catch (Exception e) {
            throw new RuntimeException("❌ Ошибка при получении заказов", e);
        }
    }

    @Transactional(readOnly = true)
    private List<Personnel> getPersonnel() {
        List<Personnel> personnel = new ArrayList<>();

        try {
            personnel = entityManager.createQuery("FROM Personnel", Personnel.class).getResultList();
            if (isEmpty(personnel)) {
                throw new RuntimeException("❌ Персонала нет");
            }
            return personnel;
        } catch (Exception e) {
            throw new RuntimeException("❌ Ошибка при получении персонала", e);
        }
    }
    
    private <T> boolean isEmpty(Collection<T> collection) {
        return collection == null || collection.isEmpty();
    }

    private List<Integer> getDiscounts(List<Clients> clients) {
        return clients.stream().map(Clients::getDiscount).collect(Collectors.toList());
    }

    private Integer getDiscount(List<Integer> discounts, boolean isMinimum) {
        if(isMinimum) {
            return discounts.stream().min(Integer::compareTo).orElse(0);
        } else {
            return discounts.stream().max(Integer::compareTo).orElse(0);
        }
    }

    private Date getAge(List<Clients> clients, boolean isYoungest) {
        if (clients == null || clients.isEmpty()) {
            return null;
        }

        if (isYoungest) {
            return clients.stream()
                    .map(Clients::getBirthDate)
                    .filter(Objects::nonNull)
                    .max(Date::compareTo)
                    .orElse(null);
        } else {
            return clients.stream()
                    .map(Clients::getBirthDate)
                    .filter(Objects::nonNull)
                    .min(Date::compareTo)
                    .orElse(null);
        }
    }

    @Transactional(readOnly = true)
    public List<Orders> getOrdersInDateRange(Date startDate, Date endDate) {
        List<Orders> orders = new ArrayList<>();

        try{
            orders = entityManager.createQuery("FROM Orders o WHERE o.createdAt BETWEEN :startDate AND :endDate", Orders.class)
                .setParameter("startDate", startDate)
                .setParameter("endDate", endDate)
                .getResultList();
            if(orders.isEmpty()) {
                throw new RuntimeException("❌ Заказов нет");
            }
            return orders;
        } catch (Exception e) {
            throw new RuntimeException("❌ Ошибка при получении заказов", e);
        }
    }

    private double getMaximumSumOfOrder(List<Orders> orders) {
        return orders.stream().mapToDouble(Orders::getTotalSum).max().orElse(0);
    }

    @Transactional(readOnly = true)
    private List<PersonnelSchedule> getPersonnelSchedules() {
        List<PersonnelSchedule> schedules = new ArrayList<>();

        try{
            schedules = entityManager.createQuery("FROM PersonnelSchedule", PersonnelSchedule.class).getResultList();
            if (isEmpty(schedules)) {
                throw new RuntimeException("❌ Расписания нет");
            }
            return schedules;
        } catch (Exception e) {
            throw new RuntimeException("❌ Ошибка при получении расписаний", e);
        }
    }
} 