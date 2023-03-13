package com.example.schedule.model.dto;

import com.squareup.moshi.FromJson;
import com.squareup.moshi.Json;

import java.io.IOException;

public class GroupDto {
    public String id;
    public String number;
    public GroupDto(String number){
        this.number = number;
    }
    public GroupDto() {}
}
