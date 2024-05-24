import { createSlice } from "@reduxjs/toolkit";
import { getAwarded, getAwardedUnique } from '../actions/actionAwarded';

const initialState = {
  awardeds: [],
  awarded: {},
  loading: false,
  error: null,
};

const awardedSlice = createSlice({
  name: "getAwarded",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(getAwarded.pending, (state) => {
        state.awardeds = [];
        state.loading = true;
        state.error = null;
      })
      .addCase(getAwarded.fulfilled, (state, action) => {
        state.awardeds = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(getAwarded.rejected, (state, action) => {
        state.awardeds = [];
        state.loading = false;
        state.error = action.error.message;
      })
      .addCase(getAwardedUnique.pending, (state) => {
        state.awarded = {};
        state.loading = true;
        state.error = null;
      })
      .addCase(getAwardedUnique.fulfilled, (state, action) => {
        state.awarded = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(getAwardedUnique.rejected, (state, action) => {
        state.awarded = {};
        state.loading = false;
        state.error = action.error.message;
      });
  },
});

export const getAwardedReducer = awardedSlice.reducer;