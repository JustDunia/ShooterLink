import axios from 'axios'
import { createAsyncThunk } from '@reduxjs/toolkit'

const setAuthHeader = token => {
	axios.defaults.headers.common.Authorization = `Bearer ${token}`
}

const clearAuthHeader = () => {
	axios.defaults.headers.common.Authorization = ''
}

export const register = createAsyncThunk('auth/register', async (userData, thunkAPI) => {
	try {
		const response = await axios.post('/api/auth/register', userData)
		return true
	} catch (e) {
		return thunkAPI.rejectWithValue(e.response.data.errors.generalErrors || e.message)
	}
})

export const logIn = createAsyncThunk('auth/login', async (userData, thunkAPI) => {
	try {
		const response = await axios.post('/api/auth/login', userData)
		setAuthHeader(response.data.token)
		return response.data
	} catch (e) {
		return thunkAPI.rejectWithValue(e.message)
	}
})

export const logOut = () => {
	clearAuthHeader()
	return { type: 'auth/logOut' }
}

// export const refreshToken = createAsyncThunk(
//   'auth/refresh',
//   async (_, thunkAPI) => {
//     const state = thunkAPI.getState();
//     const persistedToken = state.auth.token;

//     if (persistedToken === null) {
//       return thunkAPI.rejectWithValue('Unable to fetch user');
//     }

//     try {
//       setAuthHeader(persistedToken);
//       const response = await axios.get('/users/current');
//       return response.data;
//     } catch (e) {
//       return thunkAPI.rejectWithValue(e.message);
//     }
//   }
// );
