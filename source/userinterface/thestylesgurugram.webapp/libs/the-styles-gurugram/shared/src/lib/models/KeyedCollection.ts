import { IKeyedCollection } from './IKeyedCollection';

export class KeyedCollection<T> implements IKeyedCollection<T> {
  private items: { [index: string]: T } = {};

  private countItem = 0;

  public containsKey(key: string): boolean {
    return this.items.hasOwnProperty(key);
  }

  public count(): number {
    return this.countItem;
  }

  public add(key: string, value: T) {
    if (!this.items.hasOwnProperty(key)) {
      this.countItem++;
    }

    this.items[key] = value;
  }

  public remove(key: string): T {
    const val = this.items[key];
    delete this.items[key];
    this.countItem--;
    return val;
  }

  public item(key: string): T {
    return this.items[key];
  }

  public keys(): string[] {
    const keySet: string[] = [];

    for (const prop in this.items) {
      if (this.items.hasOwnProperty(prop)) {
        keySet.push(prop);
      }
    }

    return keySet;
  }

  public values(): T[] {
    const values: T[] = [];

    for (const prop in this.items) {
      if (this.items.hasOwnProperty(prop)) {
        values.push(this.items[prop]);
      }
    }

    return values;
  }
}
