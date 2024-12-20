import { configureStore } from "@reduxjs/toolkit";
import { getUserReducer } from "../slice/usersSlice";
import { getRoleReducer } from "../slice/RolesSlice";
import { getRealStateReducer } from "../slice/Real_StateSlice";
import { getAuctionReducer } from "../slice/auctionSlice";
import { getAwardedReducer } from "../slice/awardedSlice";
import { getLitigationReducer } from "../slice/litigationSlice";
import { getLitigiousReducer } from "../slice/litigiousSlice";
import { getPropertyReducer } from "../slice/propertySlice";
import { getReportReducer } from "../slice/reportSlice"

export default configureStore({
    reducer:{
        getUsers: getUserReducer,
        getRole: getRoleReducer,
        getRealState: getRealStateReducer,
        getAuction: getAuctionReducer,
        getAwarded: getAwardedReducer,
        getLitigation: getLitigationReducer,
        getLitigious: getLitigiousReducer,
        getProperty: getPropertyReducer,
        getReport: getReportReducer
    },
    middleware: (getDefaultMiddleware) => getDefaultMiddleware({ serializableCheck: false })
});