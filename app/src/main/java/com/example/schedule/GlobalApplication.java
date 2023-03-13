package com.example.schedule;

import android.app.Application;
import android.text.Selection;

import com.example.schedule.scheduleapi.ScheduleService;
import com.example.schedule.scheduleapi.SelectionService;
import com.squareup.moshi.Moshi;

import retrofit2.Retrofit;
import retrofit2.converter.jackson.JacksonConverterFactory;
import retrofit2.converter.moshi.MoshiConverterFactory;

public class GlobalApplication extends Application {
    private static SelectionService selectionService;
    private static ScheduleService scheduleService;
    private static String urlServer = "http://shonhodoev.markridge.space/api/";
    private static Retrofit retrofit;
    private static Moshi moshi;

    public SelectionService getSelectionService() {
        return selectionService;
    }

    public void setSelectionService(SelectionService _selectionService) {
        selectionService = _selectionService;
    }

    public ScheduleService getScheduleService() {
        return scheduleService;
    }

    public void setScheduleService(ScheduleService _scheduleService) {
        scheduleService = _scheduleService;
    }

    public Moshi getMoshi() {
        return moshi;
    }

    public void setMoshi(Moshi moshi) {
        this.moshi = moshi;
    }

    @Override
    public void onCreate(){
        super.onCreate();

        moshi = new Moshi.Builder().build();

        retrofit = new Retrofit.Builder()
                .baseUrl(urlServer)
                .addConverterFactory(MoshiConverterFactory.create(moshi))
                .build();
        ScheduleService scheduleService = retrofit.create(ScheduleService.class);
        SelectionService selectionService = retrofit.create(SelectionService.class);

        setScheduleService(scheduleService);
        setSelectionService(selectionService);
    }
}
