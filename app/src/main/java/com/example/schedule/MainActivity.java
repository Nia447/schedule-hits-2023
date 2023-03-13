package com.example.schedule;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.RecyclerView;
import androidx.viewpager.widget.ViewPager;
import androidx.viewpager2.widget.ViewPager2;

import android.content.Intent;
import android.content.SharedPreferences;
import android.database.DataSetObserver;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.FrameLayout;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.example.schedule.databinding.ActivityMainBinding;
import com.example.schedule.model.dto.DailyScheduleDto;
import com.example.schedule.model.dto.GroupDto;
import com.example.schedule.model.dto.GroupListDto;
import com.example.schedule.model.dto.LessonDto;
import com.example.schedule.model.dto.PeriodScheduleDto;
import com.example.schedule.model.entity.NumberLesson;
import com.example.schedule.scheduleapi.ScheduleService;
import com.example.schedule.scheduleapi.SelectionService;
import com.google.android.material.tabs.TabLayout;
import com.google.android.material.tabs.TabLayoutMediator;
import com.squareup.moshi.Moshi;

import org.joda.time.DateTime;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;

public class MainActivity extends AppCompatActivity {
    private DateTime currentMonday;
    private DateTime currentSunday;
    private String urlServer = "";
    private int currentWeek = 1;
    private Button previous_week;
    private Button next_week;
    public boolean isStudent;

    private TabLayout mTabLayout;
    private ViewPager2 mViewPager;
    private MyPagerAdapter mPagerAdapter;
    private ActivityMainBinding binding;
    private List<MyRecyclerViewAdapter> adapters;
    private PageFragment fragment;
    private ScheduleService apiService;
    private List<List<String>> strings;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        strings = new ArrayList<>();

        LessonDto lessonDto = new LessonDto("Основа командной разработки", "971101", "Змеев Денис Олегович", "302");

        mViewPager = findViewById(R.id.viewPager);
        mTabLayout = findViewById(R.id.tabLayout);

        mPagerAdapter = new MyPagerAdapter(this);
        mViewPager.setAdapter(mPagerAdapter);

        GlobalApplication application = (GlobalApplication) getApplication();
        apiService = application.getScheduleService();

        mPagerAdapter.addFragment(new PageFragment("Расписание на Понедельник", new ArrayList<>()));
        mPagerAdapter.addFragment(new PageFragment("Расписание на Вторник", new ArrayList<>()));
        mPagerAdapter.addFragment(new PageFragment("Расписание на Среду", new ArrayList<>()));
        mPagerAdapter.addFragment(new PageFragment("Расписание на Четверг",  new ArrayList<>()));
        mPagerAdapter.addFragment(new PageFragment("Расписание на Пятница",  new ArrayList<>()));
        mPagerAdapter.addFragment(new PageFragment("Расписание на Субботу",  new ArrayList<>()));
        mPagerAdapter.addFragment(new PageFragment("Расписание на Воскресенье",  new ArrayList<>()));

        Call<PeriodScheduleDto> optionsCall = apiService.getGroupPeriodScheduleDto("79da8ef7-440a-40e2-876e-2f35396afcd4");
        optionsCall.enqueue(new Callback<PeriodScheduleDto>() {
            @Override
            public void onResponse(Call<PeriodScheduleDto> call, Response<PeriodScheduleDto> response) {
                if (response.isSuccessful()) {
                    PeriodScheduleDto options = response.body();

                    int n = 0;
                    for (DailyScheduleDto day : options.days){
                        List<String> selectList = new ArrayList<>();

                        for (LessonDto lesson : day.lessons) {
                            selectList.addAll(getListStringFromLessonDto(lesson));
                        }
                        strings.add(selectList);
                    }

                    loadFragements();

                    Toast.makeText(MainActivity.this, "Ahahahah", Toast.LENGTH_SHORT).show();
                } else {
                    Toast.makeText(MainActivity.this, "Не удалось получить список вариантов", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<PeriodScheduleDto> call, Throwable t) {
                Log.i("asd", t.getMessage());
                Toast.makeText(MainActivity.this, "Ошибка: " + t.getMessage(), Toast.LENGTH_LONG).show();
            }
        });

        TabLayoutMediator tabLayoutMediator = new TabLayoutMediator(
                mTabLayout, mViewPager, (tab, position) -> tab.setText(getDayOfTheWeek(position))
        );
        tabLayoutMediator.attach();

        previous_week = findViewById(R.id.previous_week_button);
        next_week = findViewById(R.id.next_week_button);

        previous_week.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                if (currentWeek > 1) {
                    currentWeek--;
                    updateSchedule(currentMonday, currentSunday);
                }
            }
        });

        next_week.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ListView listView = findViewById(R.id.optionsListView);

                String[] data = {"item 1", "item 2", "item 3"};

                ArrayAdapter<String> adapter = new ArrayAdapter<>(MainActivity.this, android.R.layout.simple_list_item_1, data);

                listView.setAdapter(adapter);

                updateSchedule(currentMonday, currentSunday);
            }
        });



        identifyCurrentDates();

        //hideSchedule();
        //updateSchedule(currentMonday, currentSunday);*/
    }

    public void loadFragements() {
        mPagerAdapter.replaceFragment(0, new PageFragment("Расписание на Понедельник", strings.get(0)));
        mPagerAdapter.replaceFragment(1, new PageFragment("Расписание на Вторник", strings.get(1)));
        mPagerAdapter.replaceFragment(2, new PageFragment("Расписание на Среду", strings.get(2)));
        mPagerAdapter.replaceFragment(3, new PageFragment("Расписание на Четверг", strings.get(3)));
        mPagerAdapter.replaceFragment(4, new PageFragment("Расписание на Пятница", strings.get(4)));
        mPagerAdapter.replaceFragment(5, new PageFragment("Расписание на Субботу", strings.get(5)));
        mPagerAdapter.replaceFragment(6, new PageFragment("Расписание на Воскресенье", strings.get(6)));
    }

    private List<String> getListStringFromLessonDto(LessonDto lessonDto) {
        List<String> list = new ArrayList<>();
        list.add(getNumberLesson(lessonDto.numberLesson));
        list.add(lessonDto.group.number);
        list.add(lessonDto.audience.number);
        list.add(lessonDto.teacher.fullName);
        list.add(lessonDto.subject.name);
        list.add("");
        return list;
    }

    private String getNumberLesson(int n) {
        switch (n) {
            case 0:
                return "8:45 - 10:20";
            case 1:
                return "10:35 - 12:10";
            case 2:
                return "12:25 - 14:00";
            case 3:
                return "14:45 - 16:20";
            case 4:
                return "16:35 - 18:10";
            case 5:
                return "18:25 - 20:00";
            case 6:
                return "20:15 - 21:50";
            default:
                return null;
        }
    }

    private String getDayOfTheWeek(int n){
        switch (n) {
            case 0:
                return "ПН";
            case 1:
                return "ВТ";
            case 2:
                return "СР";
            case 3:
                return "ЧТ";
            case 4:
                return "ПТ";
            case 5:
                return "СБ";
            case 6:
                return "ВС";
            default:
                return null;
        }
    }
    private String getDayOfTheWeekFull(int n){
        switch (n) {
            case 0:
                return "Понеделник";
            case 1:
                return "Вторник";
            case 2:
                return "Среду";
            case 3:
                return "Четверг";
            case 4:
                return "Пятницу";
            case 5:
                return "Субботу";
            case 6:
                return "Воскресенье";
            default:
                return null;
        }
    }
    @Override
    protected void onStart() {
        super.onStart();

        Timer timer = new Timer();
        TimerTask task = new TimerTask() {
            @Override
            public void run() {
                /*hideSchedule();
                updateSchedule(currentMonday, currentSunday);*/
            }
        };
        timer.schedule(task, 1000);
    }

    private void updateSchedule(DateTime monday, DateTime sunday) {
        SharedPreferences mSharedPreferences = PreferenceManager.getDefaultSharedPreferences(this);
        Boolean IsStudent = mSharedPreferences.getBoolean("IsStudent", true);
        String Id = mSharedPreferences.getString("Id", "");
    }

    private String getTimeLesson(NumberLesson numberLesson){
        switch (numberLesson.ordinal()){
            case (0):
                return "8:45 - 10:20";
            case (1):
                return "10:35 - 12:10";
            case (2):
                return "12:25 - 14:00";
            case (3):
                return "14:45 - 16:20";
            case (4):
                return "16:35 - 18:10";
            case (5):
                return "18:25 - 20:00";
            case (6):
                return "20:15 - 21:50";
            default:
                return "None";
        }
    }

    private void identifyCurrentDates(){
        long start = System.currentTimeMillis();
        Date date = new Date(start);
        Calendar c = Calendar.getInstance();
        c.setTime(date);
        int dayOfWeek = c.get(Calendar.DAY_OF_WEEK);

        DateTime dateTime = new DateTime(date);

        if (dayOfWeek >= 1)
            currentMonday = dateTime.minusDays(dayOfWeek);
        else
            currentMonday = dateTime.minusDays(6);
        currentSunday = dateTime.plusDays(6);
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
                Intent intent = new Intent(MainActivity.this, StudentActivity.class);
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
}