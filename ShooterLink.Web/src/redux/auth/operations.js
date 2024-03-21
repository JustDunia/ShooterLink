import axios from 'axios'
import { createAsyncThunk } from '@reduxjs/toolkit'

axios.defaults.baseURL = import.meta.env.VITE_TARGET_URL

const setAuthHeader = token => {
	axios.defaults.headers.common.Authorization = `Bearer ${token}`
}

const clearAuthHeader = () => {
	axios.defaults.headers.common.Authorization = ''
}

export const register = createAsyncThunk('auth/register', async (userData, thunkAPI) => {
	try {
		const response = await axios.post('auth/register', userData)
		return response.success ? true : thunkAPI.rejectWithValue(response.data.errors.generalErrors[0])
	} catch (e) {
		return thunkAPI.rejectWithValue(e.message)
	}
})

export const logIn = createAsyncThunk('auth/login', async (userData, thunkAPI) => {
	try {
		const response = await axios.post('auth/login', userData)
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
