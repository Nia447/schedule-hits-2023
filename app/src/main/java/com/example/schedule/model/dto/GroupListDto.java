package com.example.schedule.model.dto;

import com.example.schedule.GlobalApplication;
import com.squareup.moshi.FromJson;
import com.squareup.moshi.Moshi;
import com.squareup.moshi.ToJson;

import java.io.IOException;
import java.util.List;

public class GroupListDto {
    public List<GroupDto> groups;
}
