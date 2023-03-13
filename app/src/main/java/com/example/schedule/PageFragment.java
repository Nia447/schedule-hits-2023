package com.example.schedule;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.schedule.databinding.FragmentPageBinding;
import com.example.schedule.model.dto.LessonDto;

import java.util.List;

public class PageFragment extends Fragment {

    private final String title;
    private final List<String> lessonsData;
    private RecyclerView recyclerView;
    private MyRecyclerViewAdapter adapter;
    private FragmentPageBinding binding;
    private ArrayAdapter<String> adapter2;

    public PageFragment(String title, List<String> lessonsData) {
        this.title = title;
        this.lessonsData = lessonsData;
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        binding = FragmentPageBinding.inflate(inflater, container, false);

        TextView textView = binding.getRoot().findViewById(R.id.textView);
        textView.setText(title);

        recyclerView = binding.recyclerView;
        recyclerView.setLayoutManager(new LinearLayoutManager(getContext()));

        adapter = new MyRecyclerViewAdapter();

        recyclerView.setAdapter(adapter);

        adapter2 = new ArrayAdapter<>(getContext(), android.R.layout.simple_list_item_1);
        ListView listView = binding.getRoot().findViewById(R.id.page_list_view);
        listView.setAdapter(adapter2);
        adapter2.clear();
        adapter2.addAll(lessonsData);
        adapter2.notifyDataSetChanged();

        return binding.getRoot();
    }

    public void createLessonView(LessonDto lessonDto) {
        adapter.addData("Sheesh");
    }

    public RecyclerView getRecyclerView() {
        return recyclerView;
    }

    public MyRecyclerViewAdapter getAdapter() { return adapter; }
}
