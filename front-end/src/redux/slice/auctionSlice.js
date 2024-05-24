import { createSlice } from "@reduxjs/toolkit";
import { getAuction, getAuctionUnique } from '../actions/actionAuction';

const initialState = {
  auctions: [],
  auction: {},
  loading: false,
  error: null,
};

const AuctionSlice = createSlice({
  name: "getAuction",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(getAuction.pending, (state) => {
        state.auctions = [];
        state.loading = true;
        state.error = null;
      })
      .addCase(getAuction.fulfilled, (state, action) => {
        state.auctions = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(getAuction.rejected, (state, action) => {
        state.auctions = [];
        state.loading = false;
        state.error = action.error.message;
      })
      .addCase(getAuctionUnique.pending, (state) => {
        state.auction = {};
        state.loading = true;
        state.error = null;
      })
      .addCase(getAuctionUnique.fulfilled, (state, action) => {
        state.auction = action.payload;
        state.loading = false;
        state.error = null;
      })
      .addCase(getAuctionUnique.rejected, (state, action) => {
        state.auction = {};
        state.loading = false;
        state.error = action.error.message;
      });
  },
});

export const getAuctionReducer = AuctionSlice.reducer;