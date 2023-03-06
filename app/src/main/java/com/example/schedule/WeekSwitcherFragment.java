package com.example.schedule;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;


public class WeekSwitcherFragment extends Fragment {

    private OnWeekSwitchedListener listener;

    public interface OnWeekSwitchedListener {
        void onWeekSwitched(int week);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_week_switcher, container, false);

        Button btnPrevWeek = view.findViewById(R.id.btn_prev_week);
        Button btnNextWeek = view.findViewById(R.id.btn_next_week);

        btnPrevWeek.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                listener.onWeekSwitched(-1); // переключение на предыдущую неделю
            }
        });

        btnNextWeek.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                listener.onWeekSwitched(1); // переключение на следующую неделю
            }
        });

        return view;
    }

    public void setOnWeekSwitchedListener(OnWeekSwitchedListener listener) {
        this.listener = listener;
    }
}