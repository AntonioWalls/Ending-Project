import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const getAuction = createAsyncThunk("auctions/getAuction",
    async () => {
        try
        {      
            const resp = await axios.get('http://localhost:46785/api/Inmobiliaria/lista');

            return resp.data;
        } 
        catch (error) 
        {
            return null;
        }
    }
);

export const getAuctionUnique = createAsyncThunk("auctions/getAuctionUnique",
    async (idRemate, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.get('http://187.189.158.186:7777/Usuario/'+idRemate);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const addAuction = createAsyncThunk("Auctions/addAuction",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.post('', data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const deleteAuctions = createAsyncThunk("auctions/deleteAuctions",
    async (id, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.delete('http://187.189.158.186:7777/Usuario/'+id);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);

export const editAuction = createAsyncThunk("auctions/editAuction",
    async (data, {rejectWithValue}) => {
        try
        {      
            const resp = await axios.put('http://187.189.158.186:7777/Usuario/'+data.id, data);

            return resp.data;
        } 
        catch (error) 
        {
            return rejectWithValue(`Error: ${error.message}`);
        }
    }
);
