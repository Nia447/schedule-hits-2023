package com.example.schedule.scheduleapi;

import com.example.schedule.model.dto.PeriodScheduleDto;

import org.joda.time.DateTime;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface ScheduleService {
    @GET("schedule/group/{id}")
    Call<PeriodScheduleDto> getGroupPeriodScheduleDto(@Path("id") String id);

    @GET("schedule/teacher/{id}")
    Call<PeriodScheduleDto> getTeacherPeriodScheduleDto(@Path("id") String id);
}
