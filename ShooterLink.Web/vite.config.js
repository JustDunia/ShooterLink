import { defineConfig, loadEnv } from 'vite';
import plugin from '@vitejs/plugin-react';


export default defineConfig(({ command, mode }) => {

    const env = loadEnv(mode, process.cwd(), '')

    return {
        plugins: [plugin()],
        server: {
            proxy: {
                '^/weatherforecast': {
                    target: env.TARGET_URL,
                    secure: false
                }
            },
            port: 5173
        },
    }
})