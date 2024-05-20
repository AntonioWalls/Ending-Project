import { createSlice } from "@reduxjs/toolkit";
import { getRealState, getRealStateUnique } from '../actions/ActionReal_State';

const initialState = {
  realstates: [],
  realstate: {},
  loading: false,
  error: null,
};

const RealStateSlice = createSlice({
  name: "getRealState",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(getRealState.pending, (state) => {
        state.realstates = [];
        state.loading = true;
        state.error = null;
      })
      .addCase(getRealState.fulfilled, (state, action) => {
        state.realstates = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(getRealState.rejected, (state, action) => {
        state.realstates = [];
        state.loading = false;
        state.error = action.error.message;
      })
      .addCase(getRealStateUnique.pending, (state) => {
        state.realstate = {};
        state.loading = true;
        state.error = null;
      })
      .addCase(getRealStateUnique.fulfilled, (state, action) => {
        state.realstate = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(getRealStateUnique.rejected, (state, action) => {
        state.realstate = {};
        state.loading = false;
        state.error = action.error.message;
      });
  },
});

export const getRealStateReducer = RealStateSlice.reducer;