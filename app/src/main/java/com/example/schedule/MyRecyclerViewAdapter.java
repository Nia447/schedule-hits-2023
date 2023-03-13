package com.example.schedule;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.recyclerview.widget.RecyclerView;

import com.example.schedule.databinding.LessonViewBinding;

import java.util.ArrayList;
import java.util.List;

public class MyRecyclerViewAdapter extends RecyclerView.Adapter<MyRecyclerViewAdapter.ViewHolder> {
    private List<String> mData;
    private LessonViewBinding binding;

    MyRecyclerViewAdapter() {
        mData = new ArrayList<String>();
    }

    @Override
    public MyRecyclerViewAdapter.ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.item_layout, parent, false);

        binding = LessonViewBinding.inflate(LayoutInflater.from(parent.getContext()), parent, false);

        return new ViewHolder(binding);
    }

    @Override
    public void onBindViewHolder(ViewHolder holder, int position) {
        String text = mData.get(position);

        holder.mTextView.setText(text);
    }

    @Override
    public int getItemCount() {
        return mData.size();
    }

    public void addData(String string) {
        mData.add(string);
        notifyDataSetChanged();
    }

    static class ViewHolder extends RecyclerView.ViewHolder {
        private final LessonViewBinding binding;
        TextView mTextView;

        ViewHolder(LessonViewBinding binding) {
            super(binding.getRoot());
            this.binding = binding;
            mTextView = binding.getRoot().findViewById(R.id.item_text_view);
        }
    }
}