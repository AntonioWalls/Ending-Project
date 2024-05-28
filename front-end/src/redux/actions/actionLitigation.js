import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const getLitigation = createAsyncThunk("litigation/getLitigation",
    async () => {
        try
        {      
            const resp = await axios.get('http://endingapi2.somee.com/api/Litigio/lista');

            return resp.data;
        } 
        catch (error) 
        {
            return null;
        }
    }
);

export const getLitigationUnique = createAsyncThunk("litigation/getLitigationUnique",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.get('http://endingapi2.somee.com/api/Litigio/Obtener/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const addLitigationState = createAsyncThunk("litigation/addLitigation",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.post('http://endingapi2.somee.com/api/Litigio/Guardar', data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const deleteLitigation = createAsyncThunk("litigation/deleteLitigation",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.delete('http://endingapi2.somee.com/api/Litigio/Eliminar/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const editLitigation = createAsyncThunk("litigation/editLitigation",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.put('http://endingapi2.somee.com/api/Litigio/Editar'+data.id, data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);
