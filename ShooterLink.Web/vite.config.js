import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-react';


export default defineConfig({
    plugins: [plugin()],
    server: {
        proxy: {
            '^/api': {
                target: 'https://localhost:7260',
                secure: false
            }
        }
    }
})