<script setup lang="ts">
  import { ref } from 'vue';
  import Cursor from './Cursor.vue';

  const inputRef = ref<HTMLInputElement | null>();

  const props = withDefaults(
    defineProps<{
      isPassword?: boolean;
      disabled?: boolean;
      readonly?: boolean;
    }>(),
    {
      isPassword: false,
      readonly: false,
      disabled: false,
    }
  );

  defineExpose({
    focus: () => inputRef.value?.focus(),
  });

  const inputValue = ref('');
  const emit = defineEmits<{
    (e: 'submit'): void;
    (e: 'update:modelValue', value: string): void;
  }>();
  const hasFocus = ref(false);
</script>

<template>
  <div class="relative w-full">
    <span class="flex items-center min-h-8"
      >{{ props.isPassword ? '*'.repeat(inputValue.length) : inputValue }}
      <Cursor v-if="hasFocus"></Cursor>
    </span>
    <input
      ref="inputRef"
      :disabled="disabled"
      :readonly="readonly"
      @focus="hasFocus = true"
      @blur="hasFocus = false"
      @keydown.left.prevent
      @keydown.space.prevent
      @keydown.right.prevent
      @keydown.enter="emit('submit')"
      @input="emit('update:modelValue', inputValue)"
      autofocus="true"
      class="absolute cursor-default inset-0 text-transparent outline-none border-none min-h-8"
      type="text"
      spellcheck="false"
      v-model="inputValue"
    />
  </div>
</template>
