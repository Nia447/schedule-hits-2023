package com.example.schedule;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.FragmentTransaction;
import androidx.viewpager.widget.ViewPager;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.google.android.material.tabs.TabLayout;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    private int currentWeek = 1;
    private Button previous_week;
    private Button next_week;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setupViewPager();
        previous_week = findViewById(R.id.previous_week_button);
        next_week = findViewById(R.id.next_week_button);
        previous_week.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                if (currentWeek > 1) {
                    currentWeek--;

                    updateSchedule(currentWeek);
                }
            }
        });
        next_week.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                if (currentWeek < 2) {
                    currentWeek++;
                    // обновление расписания на экране с использованием новой недели
                    updateSchedule(currentWeek);
                }
            }
        });
    }

    private void updateSchedule(int week) {
        // обновление расписания на экране с использованием заданной недели
        // ...
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_main, menu);
        return true;
    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.menu_item_schedule:

                return true;
            case R.id.menu_item_classrooms:

                return true;
            case R.id.menu_item_groups:
                Intent intent = new Intent(MainActivity.this, stud.class);
                startActivity(intent);
                return true;
            case R.id.menu_item_teachers:
                Intent intent1 = new Intent(MainActivity.this, PrepodActivity.class);
                startActivity(intent1);
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }
//    public void createTextViewsFromJson(String jsonString, LinearLayout parentLayout) {
//        try {
//            JSONArray jsonArray = new JSONArray(jsonString);
//
//            for (int i = 0; i < jsonArray.length(); i++) {
//                JSONObject jsonObject = jsonArray.getJSONObject(i);
//
//                String subject = jsonObject.getString("subject");
//                String teacher = jsonObject.getString("teacher");
//                String group = jsonObject.getString("group");
//                String room = jsonObject.getString("room");
//
//                TextView textView = new TextView(context);
//                textView.setText(subject + " " + teacher + " " + group + " " + room);
//
//                parentLayout.addView(textView);
//            }
//        } catch (JSONException e) {
//            e.printStackTrace();
//        }
//    }
    private void setupViewPager() {
        ViewPager viewPager = findViewById(R.id.view_pager);
        viewPager.setAdapter(new SchedulePagerAdapter(getSupportFragmentManager()));

        TabLayout tabLayout = findViewById(R.id.tab_layout);
        tabLayout.setupWithViewPager(viewPager);
    }
}