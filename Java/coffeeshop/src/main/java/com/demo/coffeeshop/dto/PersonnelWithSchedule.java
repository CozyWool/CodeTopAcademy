package com.demo.coffeeshop.dto;

import java.util.List;

import com.demo.coffeeshop.models.Personnel;
import com.demo.coffeeshop.models.PersonnelSchedule;

public class PersonnelWithSchedule {
    private Personnel personnel;
    private List<PersonnelSchedule> schedules;

    public PersonnelWithSchedule(Personnel personnel, List<PersonnelSchedule> schedules) {
        this.personnel = personnel;
        this.schedules = schedules;
    }

    public Personnel getPersonnel() {
        return personnel;
    }

    public List<PersonnelSchedule> getSchedules() {
        return schedules;
    }

    public void setPersonnel(Personnel personnel) {
        this.personnel = personnel;
    }

    public void setSchedules(List<PersonnelSchedule> schedules) {
        this.schedules = schedules;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("[Сотрудник: ")
                .append(personnel.getFullName())
                .append(" (")
                .append(personnel.getPosition())
                .append(")\nРасписание:\n");

        for (PersonnelSchedule schedule : schedules) {
            sb.append("  ")
                    .append(schedule.getTimeStart())
                    .append(" - ")
                    .append(schedule.getTimeEnd())
                    .append("\n");
        }
        return sb.toString();
    }
}