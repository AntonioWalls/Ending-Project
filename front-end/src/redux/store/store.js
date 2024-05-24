import { configureStore } from "@reduxjs/toolkit";
import { getUserReducer } from "../slice/usersSlice";
import { getRoleReducer } from "../slice/RolesSlice";
import { getRealStateReducer } from "../slice/Real_StateSlice";
import { getAuctionReducer } from "../slice/auctionSlice";
import { getAwardedReducer } from "../slice/awardedSlice";
import { getLitigationReducer } from "../slice/litigationSlice";
import { getLitigousReducer } from "../slice/litigiousSlice";
import { getPropertyReducer } from "../slice/propertySlice";

export default configureStore({
    reducer:{
        getUsers: getUserReducer,
        getRole: getRoleReducer,
        getRealState: getRealStateReducer,
        getAuction: getAuctionReducer,
        getAwarded: getAwardedReducer,
        getLitigation: getLitigationReducer,
        getLitigous: getLitigousReducer,
        getProperty: getPropertyReducer
    },
    middleware: (getDefaultMiddleware) => getDefaultMiddleware({ serializableCheck: false })
});