import { configureStore } from "@reduxjs/toolkit";
import { getUserReducer } from "../slice/usersSlice";
import { getRoleReducer } from "../slice/RolesSlice";
import { getRealStateReducer } from "../slice/Real_StateSlice"

export default configureStore({
    reducer:{
        getUsers: getUserReducer,
        getRole: getRoleReducer,
        getRealState: getRealStateReducer
    },
    middleware: (getDefaultMiddleware) => getDefaultMiddleware({ serializableCheck: false })
});