import { configureStore } from "@reduxjs/toolkit";
import { getUserReducer } from "../slice/usersSlice";
import { getRoleReducer } from "../slice/RolesSlice";
import { getRealStateReducer } from "../slice/Real_StateSlice";
import { getAuctionReducer } from "../slice/auctionSlice";

export default configureStore({
    reducer:{
        getUsers: getUserReducer,
        getRole: getRoleReducer,
        getRealState: getRealStateReducer,
        getAuction: getAuctionReducer
    },
    middleware: (getDefaultMiddleware) => getDefaultMiddleware({ serializableCheck: false })
});