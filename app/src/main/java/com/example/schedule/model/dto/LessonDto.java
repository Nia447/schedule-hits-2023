package com.example.schedule.model.dto;

import com.example.schedule.model.entity.DayOfTheWeek;
import com.example.schedule.model.entity.NumberLesson;
import com.example.schedule.model.entity.TypeLesson;

import org.joda.time.DateTime;

public class LessonDto {
    public String id;
    public SubjectDto subject;
    public GroupDto group;
    public TeacherDto teacher;
    public AudienceDto audience;
    public int numberLesson;

    public String startPeriodTime;
    public String endPeriodTime;

    public LessonDto(String subjectName, String groupNumber, String teacherName, String audienceNumber) {
        subject = new SubjectDto(subjectName);
        group = new GroupDto(groupNumber);
        teacher = new TeacherDto(teacherName);
        audience = new AudienceDto(audienceNumber);
    }

    public LessonDto(){};
}
