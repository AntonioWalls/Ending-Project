import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const getAwarded = createAsyncThunk("awarded/getAwarded",
    async () => {
        try
        {      
            const resp = await axios.get('http://endingapi2.somee.com/api/Adjudicado/lista');

            return resp.data;
        } 
        catch (error) 
        {
            return null;
        }
    }
);

export const getAwardedUnique = createAsyncThunk("awarded/getAwardedUnique",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.get('http://endingapi2.somee.com/api/Adjudicado/Obtener/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const addAwardedState = createAsyncThunk("awarded/addAwarded",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.post('http://endingapi2.somee.com/api/Adjudicado/Guardar', data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const deleteAwarded = createAsyncThunk("awarded/deleteAwarded",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.delete('http://endingapi2.somee.com/api/Adjudicado/Eliminar/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const editAwarded = createAsyncThunk("awarded/editAwarded",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.put('http://endingapi2.somee.com/api/Adjudicado/Editar/'+data.id, data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);
