package com.example.schedule.scheduleapi;

import com.example.schedule.model.dto.AudienceListDto;
import com.example.schedule.model.dto.GroupListDto;
import com.example.schedule.model.dto.PeriodScheduleDto;
import com.example.schedule.model.dto.SubjectListDto;
import com.example.schedule.model.dto.TeachersListDto;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface SelectionService {
    @GET("schedule/groups")
    Call<GroupListDto> getGroupListDto(@Query("searchStr") String searchStr);

    @GET("schedule/teachers")
    Call<TeachersListDto> getTeacherListDto(@Query("searchStr") String searchStr);

    @GET("schedule/audiences")
    Call<AudienceListDto> getAudienceListDto(@Query("searchStr") String searchStr);

    @GET("schedule/subjects")
    Call<SubjectListDto> getSubjectListDto(@Query("searchStr") String searchStr);
}
