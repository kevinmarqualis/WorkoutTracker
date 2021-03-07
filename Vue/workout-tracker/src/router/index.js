import Vue from 'vue'
import Router from 'vue-router'
import Hello from '@/components/Hello'
import WeightLog from '@/components/WeightLog'
import Timer from '@/components/Timer'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Hello',
      component: Hello
    },
    {
      path: '/weight-logger',
      name: 'WeightLog',
      component: WeightLog
    },
    {
      path: '/workout-timer',
      name: 'Timer',
      component: Timer
    }
  ]
})
