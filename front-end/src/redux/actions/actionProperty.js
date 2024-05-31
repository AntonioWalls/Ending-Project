import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const getProperty = createAsyncThunk("property/getProperty",
    async () => {
        try
        {      
            const resp = await axios.get('http://endingapi2.somee.com/api/Propiedad/lista');

            return resp.data;
        } 
        catch (error) 
        {
            return null;
        }
    }
);

export const getPropertyUnique = createAsyncThunk("property/getPropertyUnique",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.get('http://endingapi2.somee.com/api/Propiedad/Obtener/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const addProperty = createAsyncThunk("property/addProperty",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.post('http://endingapi2.somee.com/api/Propiedad/Guardar', data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const deleteProperty = createAsyncThunk("property/deleteProperty",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.delete('http://endingapi2.somee.com/api/Propiedad/Eliminar/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const editProperty = createAsyncThunk("property/editProperty",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.put('http://endingapi2.somee.com/api/Propiedad/Editar', data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);
